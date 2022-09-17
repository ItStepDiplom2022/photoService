import React, { useEffect, useLayoutEffect, useState } from 'react';
import { useSearchParams } from 'react-router-dom';
import useInfiniteScroll from '../hooks/infinite-scroll-hook/useInfiniteScroll';
import searchService from '../services/search.service';
import Gallery from './gallery-component/gallery';
import LoadingSpinner from './spinner/Spinner';

 const Home = () => {
  const [images, setImages] = useState([]);
  const [isFetching, setIsFetching] = useInfiniteScroll(fetchMoreContent);
  const [searchParams] = useSearchParams();
  const [lastItem, setLastItem] = useState(0);
  const [canFetchContent, setCanFetchContent] = useState(true);
  const [isFirstLoading, setIsFirstLoading] = useState(true);

  async function fetchMoreContent() {
    var params = {last: lastItem, count: 20};
    params.q = searchParams.get('q');
    params.tag = searchParams.get('tag');
    params.author = searchParams.get('author');

    if(canFetchContent && !isFirstLoading) {
      const fetched = (await searchService.search(params)).data;
      setLastItem(fetched.last);
      setCanFetchContent(!fetched.isLast);

      setImages(prevState => ([...prevState, ...fetched.items]));
    }
    setIsFetching(false);
  }

  async function fetchNewContent() {
    var params = {last: 0, count: 50};
    params.q = searchParams.get('q');
    params.tag = searchParams.get('tag');
    params.author = searchParams.get('author');

    const fetched = (await searchService.search(params)).data;
    setLastItem(fetched.last);
    setCanFetchContent(!fetched.isLast);

    setImages(fetched.items);
    setIsFirstLoading(false);
  }

  useEffect(() => {
    setLastItem(0);
    setCanFetchContent(true);
    setIsFirstLoading(true);
    fetchNewContent();
  }, [searchParams])

  return (
      <div>
        <Gallery images={images}/>
        {((canFetchContent && isFetching) || (isFirstLoading)) && <LoadingSpinner/> }
      </div>
    );
}

export default Home;