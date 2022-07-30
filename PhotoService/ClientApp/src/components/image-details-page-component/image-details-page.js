import './../shared/shared-styles.css'
import './image-details-page.css'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faArrowLeft} from '@fortawesome/free-solid-svg-icons'
import { useState } from 'react';
import { useNavigate } from 'react-router';
import CommentsSection from './comments-section-component/comments-sections';
import ImageCard from './image-card-component/image-card';

const ImageDetailsPage = () => {

    let navigate=useNavigate()

    const image = 
        {
          id: 1,
          url: "https://source.unsplash.com/random/?tech,care",
          title: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
          author:"username1",
          date:"22 October, 2021",
          likes:333,
          desctiption: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. ",
          tags:[
            'tag1','anotherTag','andAnother'
          ],
          comments:[
            {
                userName:'user1',
                date:"29 October, 2021",
                commentText:"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."
            },
            {
                userName:'user2',
                date:"29 October, 2021",
                commentText:"Lorem ipsum dolor sit amet, consectetur adipiscing elit."
            },
            {
                userName:'user3',
                date:"30 October, 2021",
                commentText:"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
            },
          ]
        }

    const onReturnClick = (e) =>{
        e.preventDefault()
        navigate(-1)
    }

    return (
       <>
        <a href="#" class="previous-btn" onClick={onReturnClick}>
            <FontAwesomeIcon icon={faArrowLeft}/>
        </a>

        <ImageCard image={image} />
        <CommentsSection comments={image.comments} commentsAmount={image.comments.length}/>
       </>
    );
}

export default ImageDetailsPage;