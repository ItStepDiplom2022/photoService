import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router';
import CollectionItem from './collection-item-component/CollectionItem';
import profileService from '../../../services/profile.service';
import './Collections.css'
import AddCollectionDialog from './add-collection-dialog-component/AddCollectionDialog';

const Collections = ({username}) => {
    const [collections, setCollections] = useState([]);
    const [showDialog, setShowDialog] = useState(false);
    const navigate = useNavigate();

    const handleCollectionClick = (id) => {
        navigate(`./collections/view/${id}`);
    }

    const handleAddCollectionClick = () => {
        setShowDialog(true);
    }

    const handleSubmitAddCollection = async (collectionName) => {
        console.log(await profileService.addNewCollection(username, collectionName));
        updateCollections(username);
    }

    const updateCollections = async (username) => {
        setCollections((await profileService.getUserCollections(username)).data);
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
            <CollectionItem data={{ name: "Add new", imageUrl: "/images/collection-images/plus.png"}}  handleClick={handleAddCollectionClick}/>
            <AddCollectionDialog isVisible={showDialog} setVisible={setShowDialog} submitAction={handleSubmitAddCollection} />
        </div>
    );
}

export default Collections;