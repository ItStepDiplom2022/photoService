import './comment.css'
import React from 'react';
import { faUser } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { data } from 'jquery';

const Comment = (props) => {

    const getDateParsed = () =>{
        let date = new Date(Date.parse(props.date))
        return date.toLocaleString()
    }

    return (
        <>
            <div className='comment-container'>
                <div className='comment-user'>
                    <FontAwesomeIcon icon={faUser} />
                </div>

                <div className="comment-text">
                    <h5><b>{props?.userName}</b> <small className='date-text'>{getDateParsed()}</small></h5>
                    <p className="">{props?.commentText}</p>
                </div>
            </div>

            <hr/>
        </>
    )
}

export default Comment;