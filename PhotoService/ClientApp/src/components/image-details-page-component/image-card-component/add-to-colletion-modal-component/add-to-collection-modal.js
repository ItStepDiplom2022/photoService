import { Autocomplete, Button, Container, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from '@mui/material';
import React, { useEffect, useState } from 'react'
import authService from '../../../../services/auth.service';
import profileService from '../../../../services/profile.service';

const AddToCollectionModal = ({ submitAction, setVisible, isVisible }) => {
    const [collections, setCollections] = useState([])
    const currentUsername = authService.getOwnerUsername()
    const [chosenCollection, setChosenCollection] = useState()

    useEffect(
        ()=>{
            fetchCollections()
        },[]
    )

    const fetchCollections = async () =>{
        let cols = await profileService.getUserCollections(currentUsername)
        setCollections(cols?.data.map(c=>c.name))
    }

    const handleCollectionChange = (e) =>{
        setChosenCollection(e.target.value)
    }

    const handleClose = () => {
        setVisible(false);
    };

    const handleCreate = () => {
        submitAction()
        setChosenCollection("Saved")
        setVisible(false);
    }

    return (
        <div>
            <Dialog open={isVisible} onClose={handleClose}>
                <Container sx={{ my: '24px' }}>
                    <DialogTitle align='center' fontWeight={"bold"} fontSize={"1.5em"}>Add to collection</DialogTitle>
                    <DialogContent>
                        <Autocomplete
                            disablePortal
                            id="combo-box-demo"
                            options={collections}
                            value={chosenCollection }
                            sx={{ width: 300, mt:1 }}
                            renderInput={(params) => <TextField {...params} label="Collection" onChange={handleCollectionChange}
                            />}
                        />
                    </DialogContent>
                    <DialogActions sx={{ ml: '3vh', width: "45vh", justifyContent: "left", paddingInlineStart: 0 }}>
                        <Button onClick={handleCreate} color="success" variant='contained'>Add</Button>
                    </DialogActions>
                </Container>
            </Dialog>
        </div>
    );
}

export default AddToCollectionModal;