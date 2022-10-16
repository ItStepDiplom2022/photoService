import React from "react";
import { useNavigate } from "react-router";
import "./gallery-item.css"

export default function GalleryItem(props)
{
    let navigate = useNavigate();
    console.log(props.image)

    return (
        <div className="gallery-item">
            <div className="content byebye" onClick={() => navigate(`/image/${props.image.id}`)}>
                <img src={props.image.imageUrl} alt="" onLoad={(ev) => {props.resizing(ev.target)}}/>
                <b className="img-title">{props.image.title}</b>
            </div>
        </div>
    );
}