import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router';
import CollectionItem from './collection-item-component/CollectionItem';
import profileService from '../../../services/profile.service';
import './Collections.css'
import AddCollectionDialog from './add-collection-dialog-component/AddCollectionDialog';
import authService from '../../../services/auth.service';

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
        await profileService.addNewCollection(authService.getOwnerUsername(),collectionName,isPublic)
        updateCollections(username);
    }

    const updateCollections = async (username) => {
        //user can`t see private collections of other users
        var onlyPublicCollections = username !== authService.getOwnerUsername()
        setCollections((await profileService.getUserCollections(username,onlyPublicCollections)).data);
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
            {username === authService.getOwnerUsername()?
                <>
                    <CollectionItem data={{ name: "Add new", imageUrl: "/images/collection-images/plus.png"}}  handleClick={handleAddCollectionClick}/>
                    <AddCollectionDialog isVisible={showDialog} setVisible={setShowDialog} submitAction={handleSubmitAddCollection} />
                </>
            :''
            }
        </div>
    );
}

export default Collections;