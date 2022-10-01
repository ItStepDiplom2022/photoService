import './NotFound.css';

const NotFound = (props) => {
    return (
        <>
        <div className='not-found-container'>
            <h1 className='not-found-title'>
                {props.message
                ?
                    props.message
                :
                    'Page not found!'}
            </h1>
        </div>
        </>
    );
}

export default NotFound;