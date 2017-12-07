import * as React from "react";
import { RouteComponentProps } from "react-router-dom";
import { connect } from "react-redux";
import Dropzone from "react-dropzone";
import { ImageFile } from "react-dropzone";

import * as UploadReplayState from "../../store/UploadReplay";
import { ApplicationState } from "../../store/index";

// At runtime, Redux will merge together...
type UploadReplayProps =
    UploadReplayState.UploadReplayState // ... state we've requested from the Redux store
    & typeof UploadReplayState.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ page: string }>; // ... plus incoming routing parameters

export class UploadReplay extends React.Component<UploadReplayProps, {}> {
    constructor(props: any) {
        super(props);
    }

    open() {
    }

    handleDropFile = (files: ImageFile[], e: React.DragEvent<HTMLDivElement>) => {
        this.props.beginUpload(files);
     };

    handleDropFiles = (accepted: File[], rejected: File[], event: React.DragEvent<HTMLDivElement>) => { };

    handleDefault = (e: React.SyntheticEvent<HTMLDivElement>) => { }

    handleFileDialog = () => { }

    render() {
        const mimeType = "application/octet-stream";

        return (
            <div>
                <Dropzone 
                    onClick={this.handleDefault}
                    onDrop={this.handleDropFiles}
                    onDropAccepted={this.handleDropFile}
                    onDropRejected={this.handleDropFile}
                    onDragStart={this.handleDefault}
                    onDragEnter={this.handleDefault}
                    onDragLeave={this.handleDefault}
                    onDragOver={this.handleDefault}
                    onFileDialogCancel={this.handleFileDialog}
                    style={{ borderStyle: "dashed", height: "100px" }}
                    className="regular"
                    multiple={false}
                    accept="*.wargamepl2"
                    name="upload-replay" />
            </div>);
    }
}

export default connect(
    (state: ApplicationState) => state.uploadReplay, // Selects which state properties are merged into the component's props
    UploadReplayState.actionCreators // Selects which action creators are merged into the component's props
)(UploadReplay) as typeof UploadReplay;