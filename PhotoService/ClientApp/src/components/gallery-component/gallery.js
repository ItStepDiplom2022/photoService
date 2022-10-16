import "./gallery.css";
import React from "react";
import GalleryItem from "./gallery-item-component/gallery-item";

export default function Gallery({images}) {

  var getVal = function (elem, style) {
    return parseInt(window.getComputedStyle(elem).getPropertyValue(style));
  };

  var getHeight = function (item) {
    return item.querySelector(".content").getBoundingClientRect().height;
  };

  var resizeAll = function () {
    var gallery = document.querySelector("#gallery");
    var altura = getVal(gallery, "grid-auto-rows");
    var gap = getVal(gallery, "grid-row-gap");
    gallery.querySelectorAll(".gallery-item").forEach(function (item) {
      var el = item;
      el.style.gridRowEnd =
        "span " + Math.ceil((getHeight(item) + gap) / (altura + gap));
    });
  };
  window.addEventListener("resize", resizeAll);
  window.addEventListener("load", resizeAll);

  function resizeItem(item) {
    if (item.complete) {
        var gallery = document.querySelector("#gallery");
        var altura = getVal(gallery, "grid-auto-rows");
        var gap = getVal(gallery, "grid-row-gap");
        var gitem = item.parentElement.parentElement;
        gitem.style.gridRowEnd =
          "span " + Math.ceil((getHeight(gitem) + gap) / (altura + gap));
        item.parentElement.classList.remove("byebye");
    }
  }

  return (
    <div className="gallery" id="gallery">
      {images.map((image) => {
        return <GalleryItem image={image} resizing={resizeItem} />;
      })}
    </div>
  );
}
