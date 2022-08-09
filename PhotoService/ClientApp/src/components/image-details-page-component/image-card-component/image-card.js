import './../../shared/shared-styles.css'
import './image-card.css'
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import Tag from '../../shared/tag-component/tag';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faShareFromSquare } from '@fortawesome/free-solid-svg-icons'
import { faDownload } from '@fortawesome/free-solid-svg-icons'
import { faSave, faHeart, faArrowLeft } from '@fortawesome/free-solid-svg-icons'
import { useEffect, useState } from 'react';

const ImageCard = (props) => {

    const [isLiked, setIsLiked] = useState(false);
    const [image] = useState(props.image)

    const onLikePressed = () => {
        setIsLiked(!isLiked)
    }

    const getDateParsed = () =>{
        let date = new Date(Date.parse(image.dateAdded))
        return `${date.getFullYear()}/${date.getMonth()}/${date.getDay()}`
    }

    const checkIfIsLiked = () =>{
        let ls = localStorage.getItem("user")
        let email = JSON.parse(ls).email

        setIsLiked( image.likes.filter(like=>like.user?.email===email).length===1)
    }

    useEffect(() => {
        checkIfIsLiked();
    },[])

    return (
        <>
            <div className='center-div'>
                <div className='card-content'>

                    <div className='image-part'>
                        <img src={image.imageBase64 } />
                    </div>

                    <div className='description-part'>
                        <h1 className='image-title'>
                            {image.title }
                        </h1>

                        <div>
                            <AccountCircleIcon className='profile-picture' />
                            <span className='image-author'>{image?.author.userName}</span>
                            <span className='divider'>|</span>
                            <span className='image-date'>{getDateParsed()}</span>
                        </div>

                            <div className='image-description'>
                                {image.description}
                            </div>

                            <div className='image-tags'>
                                <b>Tags:</b>
                                {image.hashtags?.map(tag => <Tag tagName={tag.title}></Tag>)}
                            </div>

                        <div className='buttons'>

                            <button className={isLiked ? 'btn btn-danger' : 'btn btn-secondary'} onClick={onLikePressed}>
                                <FontAwesomeIcon className='btn-icon' icon={faHeart} />
                                {isLiked ? 'Liked' : 'Like'} | {image.likes?.length}
                            </button>

                            <button className='btn btn-primary'>
                                <FontAwesomeIcon className='btn-icon' icon={faShareFromSquare} />
                                Share
                            </button>

                            <button className='btn btn-success'>
                                <FontAwesomeIcon className='btn-icon' icon={faDownload} />
                                Download
                            </button>

                            <button className='btn btn-info'>
                                <FontAwesomeIcon className='btn-icon' icon={faSave} />
                                Save
                            </button>
                        </div>

                    </div>
                </div>
            </div>

        </>
    );
}

export default ImageCard;