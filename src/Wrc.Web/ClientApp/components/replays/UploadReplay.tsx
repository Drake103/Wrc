import * as React from "react";
import { RouteComponentProps } from "react-router-dom";
import { connect } from "react-redux";
import Dropzone = require("react-dropzone");
import { ImageFile } from "react-dropzone";

import * as UploadReplayState from "../../store/UploadReplay";
import { ApplicationState } from "../../store/index";

// At runtime, Redux will merge together...
type UploadReplayProps =
    UploadReplayState.UploadReplayState // ... state we've requested from the Redux store
    & typeof UploadReplayState.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ page: string }>; // ... plus incoming routing parameters

class UploadReplayComponent extends React.Component<UploadReplayProps, {}> {

    constructor(props: any) {
        super(props);
    }

    open() {
    }

    handleDropFile = (files: ImageFile[], e: React.DragEvent<HTMLDivElement>) => {
        this.props.beginUpload(files);
    };

    handleDropFiles = (accepted: File[], rejected: File[], event: React.DragEvent<HTMLDivElement>) => { };

    render() {
        return (
            <div>
                <Dropzone onDropAccepted={this.handleDropFile} />
            </div>);
    }
}

export const UploadReplay = connect(
    (state: ApplicationState) => state.uploadReplay, // Selects which state properties are merged into the component's props
    UploadReplayState.actionCreators // Selects which action creators are merged into the component's props
)(UploadReplayComponent);