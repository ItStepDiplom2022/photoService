import './../shared/shared-styles.css'
import './image-details-page.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faArrowLeft} from '@fortawesome/free-solid-svg-icons'
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router';
import CommentsSection from './comments-section-component/comments-sections';
import ImageCard from './image-card-component/image-card';
import imageService from '../../services/image.service';
import authService from '../../services/auth.service';
import commentService from '../../services/comment.service';

const ImageDetailsPage = () => {

    let navigate=useNavigate()

    const [image,setImage]=useState()
    const [comments, setComments] = useState()
    const {id} = useParams()
    const currentUsername = authService.getOwnerUsername()
    
    useEffect(()=>{
        fetchImage()
        fetchComments()
    },[])


    const fetchImage = async () => {
        setImage(await imageService.getImage(id))
    }

    const fetchComments = async() =>{
        setComments(await commentService.getComments(id))
    }

    const addCommentHandler =  async(comment) => {
        await imageService.postCommentToImage(currentUsername,comment,id)
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
                <CommentsSection addComment={addCommentHandler} comments={comments?.data} commentsAmount={comments?.data?.length}/>
            </>
        :<div>loading</div>
    );
}

export default ImageDetailsPage;