import React from 'react'
import './CollectionItem.css'

const CollectionItem = ({data, handleClick}) => {
    return (
        <div className='collection-item' onClick={() => {handleClick(data.name)}}>
            <div className='image-wrapper'><img src={data.collectionAvatarUrl} alt='collection'/></div>
            <div className='text'><span>{data.name}</span></div>
        </div>
    );
}

export default CollectionItem;