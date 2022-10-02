import { useEffect, useState } from 'react';
import imageService from '../../../services/image.service';
import authService from '../../../services/auth.service';
import './my-uploads.css'
import { useNavigate } from 'react-router';
import ImageView from '../../shared/image-view-component/image-view';

const MyUploads = (props) => {
    const [projects, setProjects] = useState()
    const [isOwner, setIsOwner] = useState(false)    

    const navigate = useNavigate()

    useEffect(()=>{
        fetchProjects();
        setIsOwner(props.userName===authService.getOwnerUsername())
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
            {projects?.map(project=>
                    <ImageView image={project} likes={0} savings={0} downloads={0}/>
                    )}
            {isOwner?
                <button type="button" className="btn btn-link link" onClick={addNewHandle}>Add new</button>
            :null   
            }
        </>
    );
}

export default MyUploads;