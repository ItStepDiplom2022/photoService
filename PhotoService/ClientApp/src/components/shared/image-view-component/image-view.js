import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import { useState } from 'react';
import { useNavigate } from 'react-router';
import './image-view.css'
import Tag from '../tag-component/tag';

const ImageView = (props) => {
    const [image] = useState(props.image)
    const navigate = useNavigate()
    
    const handleSeeMoreClick = (e) =>{
        e.preventDefault()
        navigate(`../image/${image.id}`)
    }

    const getDateParsed = () =>{
        let date = new Date(Date.parse(image.dateAdded))
        return `${date.getFullYear()}/${date.getMonth()+1}/${date.getDate()}`
    }

    return (
        <>
            <div className='center-div'>
                <div className='upload-card-content'>

                    <div className='image-part'>
                        <img src={image.imageUrl } alt="" />
                    </div>

                    <div className='description-part'>
                        <h1 className='image-title'>
                            {image.title }
                        </h1>

                        <div>
                            <AccountCircleIcon className='profile-picture' />
                            <a href={'profile/'+image?.author.userName} className='image-author'>{image?.author.userName}</a>
                            <span className='divider'>|</span>
                            <span className='image-date'>{getDateParsed()}</span>
                        </div>

                        <br/>

                        <div className='image-tags'>
                                <b>Tags:</b>
                                {image.hashtags?.map(tag => <Tag tagName={tag.title}></Tag>)}
                        </div>

                        <button type="button" class="btn btn-link link" onClick={handleSeeMoreClick}>See more</button>
                    </div>
                </div>

                <hr className='divider'></hr>

            </div>

        </>
    );
}

export default ImageView;