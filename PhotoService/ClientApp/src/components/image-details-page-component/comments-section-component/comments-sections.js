import { useState } from 'react';
import './../../shared/shared-styles.css'
import Comment from './comment-component/comment';
import './comments-section.css'


const CommentsSection = (props) => {

    const [commentsAmount] = useState(props.commentsAmount);
    const [comments] = useState(props.comments)

    return (
        <div className='comments-wrapper'>

            <div className='add-comment'>

                <p className='comment-amount'><b>Comments ({commentsAmount})</b></p>
                <textarea class="form-control" id="exampleFormControlTextarea1" placeholder='Add your comment' rows={4}></textarea>
                <button className='btn btn-primary add-comment-btn'>Add</button>
            </div>

            <div className='all-comments'>
                {comments?.map((c) => <Comment userName={c.userAdded?.userName} date={c.dateAdded} commentText={c.commentText} />)}
            </div>
        </div>
    )
}

export default CommentsSection;