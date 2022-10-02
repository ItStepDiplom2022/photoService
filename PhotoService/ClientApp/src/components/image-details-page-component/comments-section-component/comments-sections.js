import { Alert, Snackbar } from '@mui/material';
import { useState } from 'react';
import authService from '../../../services/auth.service';
import './../../shared/shared-styles.css'
import Comment from './comment-component/comment';
import './comments-section.css'


const CommentsSection = (props) => {
    const [commentsAmount, setCommentsAmount] = useState(props.commentsAmount);
    const [comments, setComments] = useState(props.comments)
    const [snackBarOptions, setSnackBarOptions] = useState({ isOpen: false })

    const [commentText, setCommentText] = useState('')

    const addCommentHandler = () =>{
        if(!authService.isLoggedIn()){
            setSnackBarOptions({isOpen:true, severity:'error',message:'Log in to perform this action'})
            return
        }

        setCommentsAmount(commentsAmount+1)
        setComments([
            { userAdded:{userName:authService.getOwnerUsername()}, dateAdded:new Date(), commentText:commentText},
            ...comments
        ])

        setCommentText('')

        props.addComment(commentText)
    }

    const commentChangeHandler = (e) => {
        setCommentText(e.target.value)
    }

    const handleSnackBarClose = () => {
        setSnackBarOptions({ isOpen: false, severity:snackBarOptions.severity })
    };

    return (
        <div className='comments-wrapper'>

            <div className='add-comment'>
                <p className='comment-amount'><b>Comments ({commentsAmount})</b></p>
                <textarea className="form-control" onChange={commentChangeHandler} value={commentText} placeholder='Add your comment' rows={4}></textarea>
                <button disabled={commentText.length==0} className='btn btn-primary add-comment-btn' onClick={addCommentHandler}>Add</button>
            </div>

            <div className='all-comments'>
                {comments?.map((c) => <Comment userName={c.userAdded?.userName} date={c.dateAdded} commentText={c.commentText} />)}
            </div> 

            <Snackbar open={snackBarOptions.isOpen} autoHideDuration={5000} onClose={handleSnackBarClose} anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}>
                <Alert severity={snackBarOptions.severity} sx={{ width: '100%' }} onClose={handleSnackBarClose} variant="filled">
                    {snackBarOptions.message}
                </Alert>
            </Snackbar>
        </div>
    )
}

export default CommentsSection;