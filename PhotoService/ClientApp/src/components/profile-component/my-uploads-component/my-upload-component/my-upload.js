import './my-upload.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faDownload } from '@fortawesome/free-solid-svg-icons'
import { faSave, faHeart } from '@fortawesome/free-solid-svg-icons'
import { useState } from 'react';
import { useNavigate } from 'react-router';

const MyUpload = (props) => {
    const [image] = useState(props.image)
    const navigate = useNavigate()
    
    const handleSeeMoreClick = (e) =>{
        e.preventDefault()
        navigate(`../image/${image.id}`)
    }

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

                        <p className='image-details'>
                            <FontAwesomeIcon className='btn-icon' icon={faHeart} />
                            {props.likes} Likes
                        </p>

                        <p className='image-details'>
                            <FontAwesomeIcon className='btn-icon' icon={faDownload} />
                            {props.downloads} Downloads
                        </p>

                        <p className='image-details'>
                            <FontAwesomeIcon className='btn-icon' icon={faSave} />
                            {props.savings} Savings
                        </p>

                        <button type="button" class="btn btn-link link" onClick={handleSeeMoreClick}>See more</button>
                    </div>
                </div>

                <hr className='divider'></hr>

            </div>

        </>
    );
}

export default MyUpload;