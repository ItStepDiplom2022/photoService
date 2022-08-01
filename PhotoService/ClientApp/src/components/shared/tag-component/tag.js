import React from 'react';
import './tag.css';
import CloseIcon from '@mui/icons-material/Close';

export default function Tag(props){

    const onDeleteHandler = () =>{
        props.handleDelete(props.tagName)
    }

    return (
        props.canDelete?
            <div className='tag'>
                #{props.tagName}
                <CloseIcon className='delete-btn' onClick={onDeleteHandler}/>
            </div>
        :
            <div className='tag'>
                #{props.tagName}
            </div>
        )
}