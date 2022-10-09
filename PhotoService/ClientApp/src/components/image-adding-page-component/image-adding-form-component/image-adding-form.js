import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router';
import authService from '../../../services/auth.service';
import imageService from '../../../services/image.service';
import Tag from '../../shared/tag-component/tag';
import './image-adding-form.css'

const ImageAddingForm = () => {
    const [title, setTitle] = useState('')
    const [description, setDescription] = useState('')
    const [tagsCollection, setTagsCollection] = useState([]);
    const [tagsNamesCollection, setTagsNamesCollection] = useState([]);
    const [tagToAdd, setTagToAdd] = useState('')
    const [tagToDelete, setTagToDelete] = useState()
    const [isTagDeleting, setIsTagDeleting] = useState(false)
    const [image, setImage] = useState()
    const [imageName, setImageName] = useState()
    const currentUserEmail = authService.getCurrentUserEmail()

    const navigate = useNavigate()

    const deleteTagEffect = () => {
        if (isTagDeleting) {
            setTagsNamesCollection(tagsNamesCollection.filter(function (value) { return value !== tagToDelete }))
            setTagsCollection(tagsNamesCollection.filter(function (value) { return value !== tagToDelete })
                .map(t => <Tag key={t.id} tagName={t} handleDelete={deleteTag} canDelete={true} />))

            setIsTagDeleting(false)
        }
    }

    useEffect(() => {
        deleteTagEffect();
    }, [isTagDeleting])


    const onTagToAddChange = (e) => {
        setTagToAdd(e.target.value);
    }

    const onDescriptionChange = (e) => {
        setDescription(e.target.value);
    }

    const onTitleChange = (e) => {
        setTitle(e.target.value);
    }

    const onTagAdd = () => {
        if (tagsCollection.length >= 5 || tagToAdd.length === 0 || tagsNamesCollection.includes(tagToAdd))
            return;
        setTagToAdd('');
        setTagsNamesCollection([...tagsNamesCollection, tagToAdd]);
        setTagsCollection([...tagsCollection, <Tag key={tagsCollection.length - 1} tagName={tagToAdd} canDelete={true} handleDelete={deleteTag} />])
    }

    const deleteTag = (tag) => {
        setTagToDelete(tag)
        setIsTagDeleting(true)
    }

    const onImageChange = async (e) => {
        setImage(await imageService.convertImageToBase64(e.target.files[0]));
        setImageName(e.target.files[0].name);
    }

    const addImage = (e) => {
        e.preventDefault()
        
        imageService.postImage(
            title,
            description,
            tagsNamesCollection.map(function(tagName) {
                return {title:tagName}
            }),
            image,
            currentUserEmail).then((promise)=>{
                navigate(`../image/${promise.data.id}`)
            })
    }

    return (
        <>
            <div className='container'>
                <form className='form-container' onSubmit={addImage}>
                    <h2 className='form-title'>Add your new image</h2>
                    <p className='form-subtitle'>Fill the following form to add an image</p>

                    <div className="form-group">
                        <label for="title">Title:</label>
                        <input
                            type="text"
                            className="form-control"
                            id="title"
                            placeholder="Enter title"
                            onChange={onTitleChange}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label for="description">Short description (2-3 sentences):</label>
                        <textarea
                            rows={7}
                            className="form-control"
                            id="description"
                            placeholder="Enter description"
                            onChange={onDescriptionChange}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label for="file">Add image:</label>
                        <input
                            className="form-control"
                            type="file"
                            formControlName="file"
                            id='file'
                            accept=".gif,.jpg,.jpeg,.png,.img"
                            onChange={onImageChange}
                            required />
                    </div>

                    {image !== undefined ?
                        <div className='center-div'>
                            <img
                                width="50%"
                                src={image}
                                loading="lazy"
                            />
                            {imageName}
                        </div>
                        : null
                    }


                    <div className="form-group">
                        <label for="tags">Add tags:</label>
                        <div className="flex-group">
                            <input type="text" className="form-control tag-input" id="tags" placeholder="Enter tag" value={tagToAdd} onChange={onTagToAddChange} />
                            <button className='btn btn-primary' onClick={onTagAdd} disabled={tagsCollection.length >= 5 || tagToAdd.length === 0 || tagsNamesCollection.includes(tagToAdd)}>Add</button>
                        </div>
                    </div>

                    <div className='tags-collection'>
                        {tagsCollection}
                    </div>

                    <button className='btn btn-success btn-submit'>
                        Submit
                    </button>
                </form>
            </div>
        </>
    );
}

export default ImageAddingForm;