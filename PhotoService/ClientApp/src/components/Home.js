import React, { useEffect, useLayoutEffect, useState } from 'react';
import { useSearchParams } from 'react-router-dom';
import searchService from '../services/search.service';
import Gallery from './gallery-component/gallery';

 const Home = () => {
  const [images, setImages] = useState([]);
  const [searchParams] = useSearchParams();

  async function loadContent() {
    var params = {};
    params.q = searchParams.get('q');
    params.tag = searchParams.get('tag');
    params.author = searchParams.get('author');

    setImages((await searchService.search(params)).data);
    console.log(images);
  }

  useEffect(() => {
    loadContent();
  }, [searchParams])

  return (
      <div>
        <Gallery images={images}/>
      </div>
    );
}

export default Home;