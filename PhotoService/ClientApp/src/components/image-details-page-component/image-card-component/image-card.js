import './../../shared/shared-styles.css'
import './image-card.css'
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import Tag from '../../shared/tag-component/tag';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faShareFromSquare } from '@fortawesome/free-solid-svg-icons'
import { faDownload } from '@fortawesome/free-solid-svg-icons'
import { faSave, faHeart, faArrowLeft } from '@fortawesome/free-solid-svg-icons'
import { useState } from 'react';

const ImageCard = (props) => {

    const [isLiked, setIsLiked] = useState(false);
    const [image] = useState(props.image)

    const onLikePressed = () => {
        setIsLiked(!isLiked)
    }

    return (
        <>
            <div className='center-div'>
                <div className='card-content'>

                    <div className='image-part'>
                        <img src={image.url} />
                    </div>

                    <div className='description-part'>
                        <h1 className='image-title'>
                            Imagine this is title
                        </h1>

                        <div>
                            <AccountCircleIcon className='profile-picture' />
                            <span className='image-author'>{image.author}</span>
                            <span className='divider'>|</span>
                            <span>{image.date}</span>
                        </div>

                        <div className='image-description'>
                            {image.desctiption}
                        </div>

                        <div className='image-tags'>
                            <b>Tags:</b>
                            {image.tags.map(tag => <Tag tagName={tag}></Tag>)}
                        </div>

                        <div className='buttons'>

                            <button className={isLiked ? 'btn btn-danger' : 'btn btn-secondary'} onClick={onLikePressed}>
                                <FontAwesomeIcon className='btn-icon' icon={faHeart} />
                                {isLiked ? 'Liked' : 'Like'} | {image.likes}
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