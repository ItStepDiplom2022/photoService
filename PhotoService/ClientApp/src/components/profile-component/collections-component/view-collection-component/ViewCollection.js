import React, { useEffect, useState } from 'react'
import authService from '../../../../services/auth.service';
import imageService from '../../../../services/image.service';
import ImageView from '../../../shared/image-view-component/image-view';
import NotFound from '../../../shared/not-found-component/NotFound';
import LoadingSpinner from '../../../spinner/Spinner';
import './ViewCollection.css'

const ViewCollection = (props) => {
    const [collection, setCollection] = useState()
    const [isFetching, setIsFetching] = useState(true)
    const [isEnabled, setIsEnabled] = useState()

    const fetchImages = (username,collectionName) => {
        imageService.getImagesByCollection(username,collectionName)
        .then(response=>{
            setIsFetching(false)
            setIsEnabled(response.data.isPublic||authService.getCurrentUserUsername()===response.data.user?.userName)
            setCollection(response.data)
        })
    }


    useEffect(() => {
        fetchImages(props.username,props.collectionName);
    })

    return (
        <>
            {isFetching?
                <LoadingSpinner/>
            :
            isEnabled?
            (
                collection?.images.length!==0?
                collection?.images?.map(image=>
                    <ImageView image={image} likes={0} savings={0} downloads={0}/>)
                : <NotFound message="Nothing found :("/>
            )
            :
            <NotFound message="No access :("/>
            }
        </>
    );
}

export default ViewCollection;