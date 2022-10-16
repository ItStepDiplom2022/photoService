import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router';
import CollectionItem from './collection-item-component/CollectionItem';
import './Collections.css'
import AddCollectionDialog from './add-collection-dialog-component/AddCollectionDialog';
import authService from '../../../services/auth.service';
import collectionService from '../../../services/collection.service';
import NotFound from '../../shared/not-found-component/NotFound';
import LoadingSpinner from '../../spinner/Spinner';

const Collections = ({ username }) => {
    const [collections, setCollections] = useState();
    const [showDialog, setShowDialog] = useState(false);
    const navigate = useNavigate();

    const handleCollectionClick = (name) => {
        navigate(`./collections/?collectionName=${name}`);
    }

    const handleAddCollectionClick = () => {
        setShowDialog(true);
    }

    const handleSubmitAddCollection = async (collectionName, isPublic) => {
        await collectionService.addNewCollection(authService.getCurrentUserUsername(), collectionName, isPublic)
        updateCollections(username);
    }

    const updateCollections = async (username) => {
        var onlyPublicCollections = username !== authService.getCurrentUserUsername()
        setCollections((await collectionService.getUserCollections(username, onlyPublicCollections)).data);
    }

    useEffect(() => {
        updateCollections(username);
    }, [username])

    return (
        <div className='collections-component'>
            {
                !collections ?
                    <div className='center-spinner'>
                        <LoadingSpinner />
                    </div>
                    :
                    <>
                        {(collections.length > 0 || username === authService.getCurrentUserUsername()) ?
                            collections.map((value) => {
                                return (
                                    <CollectionItem data={value} handleClick={handleCollectionClick} />
                                );
                            })
                            : <NotFound message="Nothing found :(" />
                        }

                        {username === authService.getCurrentUserUsername() ?
                            <>
                                <CollectionItem data={{ name: "Add new", collectionAvatarUrl: "/images/collection-images/plus.png" }} handleClick={handleAddCollectionClick} />
                                <AddCollectionDialog isVisible={showDialog} setVisible={setShowDialog} submitAction={handleSubmitAddCollection} />
                            </>
                            : ""
                        }
                    </>
            }
        </div>
    );
}

export default Collections;