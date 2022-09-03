import './../shared/shared-styles.css'
import './image-details-page.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faArrowLeft} from '@fortawesome/free-solid-svg-icons'
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import CommentsSection from './comments-section-component/comments-sections';
import ImageCard from './image-card-component/image-card';
import imageService from '../../services/image.service';

const ImageDetailsPage = () => {

    let navigate=useNavigate()

    const [image,setImage]=useState()
    const {id} = useParams()
    
    useEffect(()=>{
        fetchImage()
    },[])

    const fetchImage = async () => {
        setImage(await imageService.getImage(id))
        }

    const onReturnClick = (e) =>{
        e.preventDefault()
        navigate(-1)
    }

    return (
        image?
            <>
                <a href="#" className="previous-btn" onClick={onReturnClick}>
                    <FontAwesomeIcon icon={faArrowLeft}/>
                </a>
                <ImageCard image={image.data} />
                <CommentsSection comments={image.data?.comments} commentsAmount={image.data?.comments?.length}/>
            </>
        :<div>loading</div>
    );
}

export default ImageDetailsPage;