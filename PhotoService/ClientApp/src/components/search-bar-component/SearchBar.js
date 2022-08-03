import React, { useState } from "react";
import SearchIcon from "@mui/icons-material/Search";
import Close from "@mui/icons-material/Close";
import "./SearchBar.css";
import DataItem from "./dataItem-component/DataItem";
import { useNavigate } from "react-router";
import SearchService from "../../services/search.service";

function SearchBar({ placeholder="" }) {
  const [filterData, setFilterData] = useState([]);
  const [wordEntered, setWordEntered] = useState("");
  const navigate = useNavigate();

  const handleFilter = async (event) => {
    const searchWord = event.target.value;
    setWordEntered(searchWord);
    let newFilter = [];
    if (searchWord !== "") {
      newFilter = await SearchService.getByFilter(searchWord);
    }

    console.log(newFilter);

    setFilterData(newFilter);
  };

  const clearInput = () => {
    setFilterData([]);
    setWordEntered("");
  };

  const defaultSearch = () => {
    if(wordEntered !== "")
      navigate(`/?q=${wordEntered}`);
  }

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
              navigate(`/?q=${wordEntered}`);
            }
          }}
        />
        <div className="searchIcon">
          {filterData.length === 0 ? (
            <SearchIcon id="searchBtn" onClick={defaultSearch}/>
          ) : (
            <Close id="clearBtn" onClick={clearInput} />
          )}
        </div>
      </div>
      {filterData.length !== 0 && (
        <div className="dataResult">
          {filterData.slice(0, 15).map((value, key) => {
            return (
              <DataItem 
                displayText={value.label}
                link={value.url} 
                avatarUrl={value.avatarUrl}
                />
            );
          })}
        </div>
      )}
    </div>
  );
}

export default SearchBar;
