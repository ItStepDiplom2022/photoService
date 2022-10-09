import React, { useEffect, useState } from 'react'
import authService from '../../../../services/auth.service';
import imageService from '../../../../services/image.service';
import ImageView from '../../../shared/image-view-component/image-view';
import NotFound from '../../../shared/not-found-component/NotFound';
import './ViewCollection.css'

const ViewCollection = (props) => {
    const [collection, setCollection] = useState()

    const fetchImages = async (username,collectionName) => {
        setCollection((await imageService.getImagesByColection(username,collectionName)).data)
    }

    const havePermissionToView= () => {
        return collection?.isPublic||authService.getCurrentUserUsername()===collection?.user?.userName
    }

    useEffect(() => {
        fetchImages(props.username,props.collectionName);
    }, [])

    return (
        <>
            {
            havePermissionToView()?
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