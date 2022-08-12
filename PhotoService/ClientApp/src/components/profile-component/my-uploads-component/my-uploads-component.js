import { useEffect, useState } from 'react';
import imageService from '../../../services/image.service';
import authService from '../../../services/auth.service';
import MyUpload from './my-upload-component/my-upload-component';

const MyUploads = () => {
    const [projects, setProjects] = useState()
    const [userEmail] = useState(authService.getOwnerEmail())

    useEffect(()=>{
        fetchProjects();
    },[])

    const fetchProjects = async () => {
        const data = await imageService.getImagesByUserEmail(userEmail)
        setProjects(data.data)
    }

    return (
        <>
            {projects?.map(project=>
                    <MyUpload image={project} likes={0} savings={0} downloads={0}/>
                    )}
        </>
    );
}

export default MyUploads;