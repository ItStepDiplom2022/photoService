import { useEffect, useState } from 'react';
import imageService from '../../../services/image.service';
import authService from '../../../services/auth.service';
import './my-uploads.css'
import { useNavigate } from 'react-router';
import ImageView from '../../shared/image-view-component/image-view';
import LoadingSpinner from '../../spinner/Spinner';

const MyUploads = (props) => {
    const [projects, setProjects] = useState()
    const [isCurrentUser, setIsCurrentUser] = useState(false)    

    const navigate = useNavigate()

    useEffect(()=>{
        fetchProjects();
        setIsCurrentUser(props.userName===authService.getCurrentUserUsername())
    },[])

    const fetchProjects = async () => {
        const data = await imageService.getImagesByUserName(props.userName)
        setProjects(data.data)
    }

    const addNewHandle = () => {
        navigate('../image/add')
    }

    return (
        <>
            {isCurrentUser?
                <div className='button-div'>
                    <button type="button" className="btn btn-outline-primary" onClick={addNewHandle}>Add new</button>
                </div>
            :null   
            }
            {
            !projects?
                <LoadingSpinner/>
            :
                projects?.map(project=>
                    <ImageView image={project} likes={0} savings={0} downloads={0}/>
                    )}
        </>
    );
}

export default MyUploads;