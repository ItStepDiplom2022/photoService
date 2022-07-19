import React from "react";
import { useNavigate } from "react-router";

export default function GalleryItem(props)
{
    let navigate = useNavigate();

    let maxTitleLength = 35;
    let shortTitle = props.image.title;
    if(shortTitle.length > maxTitleLength) {
        shortTitle =  shortTitle.substring(0, maxTitleLength-3).concat('...');
    }

    return (
        <div className="gallery-item">
            <div className="content byebye" onClick={() => navigate(`/path/${props.image.id}`)}>
                <img src={props.image.url} alt="" onLoad={(ev) => {props.resizing(ev.target)}}/>
                <b>{shortTitle}</b>
            </div>
        </div>
    );
}