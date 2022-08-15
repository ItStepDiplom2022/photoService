import React from 'react'
import { useNavigate } from 'react-router';
import CollectionItem from './collection-item-component/CollectionItem';
import './Collections.css'

const Collections = ({items}) => {
    const navigate = useNavigate();

    const handleCollectionClick = (id) => {
        navigate(`./collections/view/${id}`);
    }
    const handleAddCollectionClick = () => {
        navigate(`./collections/add`);
    }

    return (
        <div className='collections-component'>
            {
                items.map((value) => {
                    return (
                        <CollectionItem data={value} handleClick={handleCollectionClick}/>
                    );
                })
            }
            <CollectionItem data={{name: "Add new", url: "images/temp/plus.png"}}  handleClick={handleAddCollectionClick}/>
        </div>
    );
}

export default Collections;