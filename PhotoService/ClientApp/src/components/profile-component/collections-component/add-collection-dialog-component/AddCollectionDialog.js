import { Button, Checkbox, Container, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, FormControlLabel, TextField } from '@mui/material';
import React, { useState } from 'react'
import profileService from '../../../../services/profile.service';

const AddCollectionDialog = ({submitAction, setVisible, isVisible}) => {
    const [entered, setEntered] = useState("")
    const [isPublic, setIsPublic] = useState(false)

    const handleChange = (ev) => {
        setEntered(ev.target.value);
    }

    const handleIsPublicChange  = (e) =>{
        setIsPublic(e.target.checked)
    }

    const handleClose = () => {
        setVisible(false);
    };

    const handleCreate = () => {
        submitAction(entered,isPublic)
        console.log(entered)
        setEntered("")
        setVisible(false);
    }

    return (
        <div>
            <Dialog open={isVisible} onClose={handleClose}>
                <Container sx={{my: '24px'}}>
                    <DialogTitle align='center' fontWeight={"bold"} fontSize={"1.5em"}>Creating collection</DialogTitle>
                    <DialogContent>
                        <TextField 
                            id="outlined-basic"
                            label="Collection name" 
                            placeholder='Name'
                            variant="outlined" 
                            value={entered}
                            onChange={handleChange}
                            sx={{
                                width: "45vh",
                                my: "5px"
                            }}
                        />
                        <br/>
                        <FormControlLabel control={<Checkbox value={isPublic} onChange={handleIsPublicChange}/>} label="Is public" />
                    </DialogContent>
                    <DialogActions sx={{mx: 'auto', width: "45vh", justifyContent: "left", paddingInlineStart: 0}}>
                        <Button onClick={handleCreate} color="success" variant='contained'>Create</Button>
                    </DialogActions>
                </Container>
            </Dialog>
        </div>
    );
}

export default AddCollectionDialog;
