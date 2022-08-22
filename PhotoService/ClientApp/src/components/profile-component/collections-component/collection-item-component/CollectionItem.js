import React from 'react'
import './CollectionItem.css'

const CollectionItem = ({data, handleClick}) => {
    return (
        <div className='collection-item' onClick={() => {handleClick(data.urlName)}}>
            <div className='image-wrapper'><img src={data.imageUrl} alt='collection'/></div>
            <div className='text'><span>{data.name}</span></div>
        </div>
    );
}

export default CollectionItem;