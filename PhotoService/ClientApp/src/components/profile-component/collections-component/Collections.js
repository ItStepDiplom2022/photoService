import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router';
import CollectionItem from './collection-item-component/CollectionItem';
import './Collections.css'
import AddCollectionDialog from './add-collection-dialog-component/AddCollectionDialog';
import authService from '../../../services/auth.service';
import collectionService from '../../../services/collection.service';

const Collections = ({username}) => {
    const [collections, setCollections] = useState([]);
    const [showDialog, setShowDialog] = useState(false);
    const navigate = useNavigate();

    const handleCollectionClick = (name) => {
        navigate(`./collections/?collectionName=${name}`);
    }

    const handleAddCollectionClick = () => {
        setShowDialog(true);
    }

    const handleSubmitAddCollection = async (collectionName, isPublic) => {
        await collectionService.addNewCollection(authService.getCurrentUserUsername(),collectionName,isPublic)
        updateCollections(username);
    }

    const updateCollections = async (username) => {
        var onlyPublicCollections = username !== authService.getCurrentUserUsername()
        setCollections((await collectionService.getUserCollections(username,onlyPublicCollections)).data);
    }

    useEffect(() => {
        updateCollections(username);
    }, [])

    return (
        <div className='collections-component'>
            {
                collections.map((value) => {
                    return (
                        <CollectionItem data={value} handleClick={handleCollectionClick}/>
                    );
                })
            }
            {username === authService.getCurrentUserUsername()?
                <>
                    <CollectionItem data={{ name: "Add new", imageUrl: "/images/collection-images/plus.png"}}  handleClick={handleAddCollectionClick}/>
                    <AddCollectionDialog isVisible={showDialog} setVisible={setShowDialog} submitAction={handleSubmitAddCollection} />
                </>
            :""
            }
        </div>
    );
}

export default Collections;