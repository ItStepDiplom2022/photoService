import { useState } from 'react';
import authService from '../../../services/auth.service';
import './../../shared/shared-styles.css'
import Comment from './comment-component/comment';
import './comments-section.css'


const CommentsSection = (props) => {
    const [commentsAmount, setCommentsAmount] = useState(props.commentsAmount);
    const [comments, setComments] = useState(props.comments)

    const [commentText, setCommentText] = useState('')

    const addCommentHandler = () =>{
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
        </div>
    )
}

export default CommentsSection;