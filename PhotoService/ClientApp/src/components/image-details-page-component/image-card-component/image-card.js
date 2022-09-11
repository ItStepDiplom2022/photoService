import './../../shared/shared-styles.css'
import './image-card.css'
import AccountCircleIcon from '@mui/icons-material/AccountCircle';
import Tag from '../../shared/tag-component/tag';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faShareFromSquare } from '@fortawesome/free-solid-svg-icons'
import { faDownload } from '@fortawesome/free-solid-svg-icons'
import { faSave, faHeart, faArrowLeft } from '@fortawesome/free-solid-svg-icons'
import { useEffect, useState } from 'react';
import AddToCollectionModal from './add-to-colletion-modal-component/add-to-collection-modal';
import { Alert, Snackbar } from '@mui/material';
import authService from '../../../services/auth.service';

const ImageCard = (props) => {
    const [isLiked, setIsLiked] = useState(false);
    const [image] = useState(props.image)
    const [showDialog, setShowDialog] = useState(false);
    const [snackBarOptions, setSnackBarOptions] = useState({ isOpen: false })

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
        //checkIfIsLiked();
    },[])

    const createFileDonwloadName = () => {
        return image.title + '.' + image.imageBase64.slice(
            image.imageBase64.indexOf('/')+1,image.imageBase64.indexOf(';')
        )
    }

    const handleAddToCollection = async (collectionName, isPublic) => {
        alert(23)
    }

    const handleSaveWindowOpen = () =>{
        if(authService.isLoggedIn())
            setShowDialog(true);
        else
            setSnackBarOptions({isOpen:true, severity:'error',message:'Log in to do this action'})
    }

    const handleSnackBarClose = (event) => {
        setSnackBarOptions({ isOpen: false, severity:'error' })
    };

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
                            <a href={'profile/'+image?.author.userName} className='image-author'>{image?.author.userName}</a>
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
                                <a className='download-link' download={createFileDonwloadName()} href={image.imageBase64}>
                                    <FontAwesomeIcon className='btn-icon' icon={faDownload} />
                                    Download</a>
                            </button>

                            <button className='btn btn-info' onClick={handleSaveWindowOpen}>
                                <FontAwesomeIcon className='btn-icon' icon={faSave}/>
                                Save
                            </button>
                        </div>

                    </div>
                </div>
                <AddToCollectionModal isVisible={showDialog} setVisible={setShowDialog} submitAction={handleAddToCollection}/>

                <Snackbar open={snackBarOptions.isOpen} autoHideDuration={5000} onClose={handleSnackBarClose} anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}>
                <Alert severity={snackBarOptions.severity} sx={{ width: '100%' }} onClose={handleSnackBarClose} variant="filled">
                    {snackBarOptions.message}
                </Alert>
            </Snackbar>
            </div>

        </>
    );
}

export default ImageCard;