import React from 'react'
import './CollectionItem.css'

const CollectionItem = ({data, handleClick}) => {
    return (
        <div className='collection-item' onClick={() => {handleClick(data.id)}}>
            <div className='image-wrapper'><img src={data.url} alt='collection'/></div>
            <div className='text'><span>{data.name}</span></div>
        </div>
    );
}

export default CollectionItem;