import { Button, Container, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@mui/material';
import React, { useState } from 'react'
import profileService from '../../../../services/profile.service';

const AddCollectionDialog = ({submitAction, setVisible, isVisible}) => {
    const [entered, setEntered] = useState("")

    const handleChange = (ev) => {
        setEntered(ev.target.value);
    }

    const handleClose = () => {
        setVisible(false);
    };

    const handleCreate = () => {
        submitAction(entered)
        console.log(entered)
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
