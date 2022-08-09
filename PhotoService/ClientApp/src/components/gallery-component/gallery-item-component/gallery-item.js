import React from "react";
import { useNavigate } from "react-router";
import "./gallery-item.css"

export default function GalleryItem(props)
{
    let navigate = useNavigate();

    return (
        <div className="gallery-item">
            <div className="content byebye" onClick={() => navigate(`/path/${props.image.id}`)}>
                <img src={props.image.imageBase64} alt="" onLoad={(ev) => {props.resizing(ev.target)}}/>
                <b className="img-title">{props.image.title}</b>
            </div>
        </div>
    );
}