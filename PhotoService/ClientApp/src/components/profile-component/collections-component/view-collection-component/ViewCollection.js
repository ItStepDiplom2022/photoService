import React, { useEffect, useState } from 'react'
import imageService from '../../../../services/image.service';
import ImageView from '../../../shared/image-view-component/image-view';
import './ViewCollection.css'

const ViewCollection = (props) => {
    const [images, setImages] = useState([]);

    const fetchImages = async (username,collectionName) => {
        setImages((await imageService.getImagesByColection(username,collectionName)).data);
    }

    useEffect(() => {
        fetchImages(props.username,props.collectionName);
    }, [])

    return (
        <>
            {
            images?.map(image=>
                    <ImageView image={image} likes={0} savings={0} downloads={0}/>
            )
            }
        </>
    );
}

export default ViewCollection;