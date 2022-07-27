import React from "react";
import "./DataItem.css";

function DataItem({ displayText, link="#", avatarUrl=""}) {
  return (
    <a className="dataItem" href={link}>
      <div className="avatar-wrapper">
        { avatarUrl !== "" ? <img src={avatarUrl} height="100%" width="100%" alt="avatar"/> : <div/>}
      </div>
      <p>{displayText}</p>
    </a>
  );
}

export default DataItem;
