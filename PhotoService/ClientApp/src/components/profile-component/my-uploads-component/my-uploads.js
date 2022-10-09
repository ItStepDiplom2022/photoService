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
            {!projects?<LoadingSpinner/>:
            projects?.map(project=>
                    <ImageView image={project} likes={0} savings={0} downloads={0}/>
                    )}
            {isCurrentUser?
                <button type="button" className="btn btn-link link" onClick={addNewHandle}>Add new</button>
            :null   
            }
        </>
    );
}

export default MyUploads;