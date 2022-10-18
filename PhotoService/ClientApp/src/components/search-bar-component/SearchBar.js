import React, { useState } from "react";
import SearchIcon from "@mui/icons-material/Search";
import Close from "@mui/icons-material/Close";
import "./SearchBar.css";
import DataItem from "./dataItem-component/DataItem";
import { useNavigate } from "react-router";
import SearchService from "../../services/search.service";

function SearchBar({ placeholder = "Search..." }) {
  const [filterData, setFilterData] = useState([]);
  const [wordEntered, setWordEntered] = useState("");
  const [isOnFocus, setIsOnFocus] = useState(false);
  const navigate = useNavigate();

  const handleFilter = async (event) => {
    const searchWord = event.target.value;
    setWordEntered(searchWord);
    let newFilter = [];
    if (searchWord !== "") {
      newFilter = (await SearchService.getByFilter(searchWord)).data;
    }

    setFilterData(newFilter);
  };

  const clearInput = () => {
    setFilterData([]);
    setWordEntered("");
  };

  const defaultSearch = () => {
    if (wordEntered !== "") navigate(`/?q=${wordEntered}`);
  };

  return (
    <div className="search">
      <div
        className="searchInputs"
        onFocus={(e) => {
          setIsOnFocus(true);
          handleFilter(e);
        }}
      >
        <input
          type="text"
          placeholder={placeholder}
          value={wordEntered}
          onChange={handleFilter}
          onKeyPress={(ev) => {
            if (ev.key === "Enter") {
              navigate(`/?q=${wordEntered}`);
              setIsOnFocus(false);
            }
          }}
        />
        <div className="searchIcon">
          {filterData.length === 0 ? (
            <SearchIcon id="searchBtn" onClick={defaultSearch} />
          ) : (
            <Close id="clearBtn" onClick={clearInput} />
          )}
        </div>
      </div>
      {filterData.length !== 0 && isOnFocus && (
        <div className="dataResult">
          {filterData.slice(0, 15).map((value, key) => {
            let searchType;

            if (value.type == 0) {
              searchType = "/?author=";
            } else {
              searchType = "/?tag=";
            }

            let handler = () => {
              navigate(searchType + value.text);
              setIsOnFocus(false);
              setWordEntered(value.text);
            };

            return (
              <DataItem
                displayText={value.text}
                handleClick={handler}
                imageUrl={value.imageUrl}
              />
            );
          })}
        </div>
      )}
    </div>
  );
}

export default SearchBar;
