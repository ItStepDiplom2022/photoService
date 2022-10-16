import React from "react";
import "./DataItem.css";

function DataItem({ displayText, handleClick, imageUrl=""}) {
  return (
    <div className="dataItem" onClick={handleClick}>
      <div className="image-wrapper">
        { imageUrl !== "" && imageUrl !== null ? <img src={imageUrl} height="100%" width="100%" alt=""/> : <div/>}
      </div>
      <p>{displayText}</p>
    </div>
  );
}

export default DataItem;
