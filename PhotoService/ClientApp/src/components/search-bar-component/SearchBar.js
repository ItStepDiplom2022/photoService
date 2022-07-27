import React, { useState } from "react";
import SearchIcon from "@mui/icons-material/Search";
import Close from "@mui/icons-material/Close";
import "./SearchBar.css";
import DataItem from "./dataItem-component/DataItem";
import { useNavigate } from "react-router";

function SearchBar({ placeholder="", data=[], labelKey=["label"], urlKey=["url"] }) {
  const [filterData, setFilterData] = useState([]);
  const [wordEntered, setWordEntered] = useState("");
  const navigate = useNavigate();

  const handleFilter = (event) => {
    const searchWord = event.target.value;
    setWordEntered(searchWord);
    let newFilter = data.filter((value) => {
      return value.label.toLowerCase().includes(searchWord.toLowerCase());
    });
    if (searchWord === "") {
      setFilterData([]);
      return;
    }
    //teat part
    if (newFilter.length === 0) {
      newFilter = [{label: searchWord, url: `/PATH?tag=${searchWord}`},{label: searchWord, url: `/PATH?autor=${searchWord}`}]
    }
    //
    setFilterData(newFilter);
  };

  const clearInput = () => {
    setFilterData([]);
    setWordEntered("");
  };

  const getKeyArray = (key) => (Array.isArray(key) ? [...key] : [key]);

  const getValueByKey = (obj, key) => {
    return getKeyArray(key).reduce((acc, curKey) => acc[curKey], obj);
  };

  return (
    <div className="search">
      <div className="searchInputs">
        <input
          type="text"
          placeholder={placeholder}
          value={wordEntered}
          onChange={handleFilter}
          onKeyPress={(ev) => {
            if (ev.key === "Enter") {
              //test part
              navigate(`/PATH?q=${wordEntered}`);
              //
            }
          }}
        />
        <div className="searchIcon">
          {filterData.length === 0 ? (
            <SearchIcon id="searchBtn" onClick={() => navigate(`/PATH?q=${wordEntered}`)}/>
          ) : (
            <Close id="clearBtn" onClick={clearInput} />
          )}
        </div>
      </div>
      {filterData.length != 0 && (
        <div className="dataResult">
          {filterData.slice(0, 15).map((value, key) => {
            return (
              <DataItem 
                //test part
                displayText={getValueByKey(value, labelKey)} link={getValueByKey(value, urlKey)} avatarUrl={key % 2 ? "https://i.pinimg.com/564x/c3/c5/a4/c3c5a4a61a8782051eb2bf2d033ef512.jpg" : ""
                //
              } />
            );
          })}
        </div>
      )}
    </div>
  );
}

export default SearchBar;
