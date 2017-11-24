import * as React from "react";
import { RouteComponentProps } from "react-router-dom";
import { connect } from "react-redux";

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
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(selectorFiles: FileList) {
        this.props.beginUpload(selectorFiles);
    }

    render() {
        return (
            <div>
                <input type="file" onChange={(e: any) => this.handleChange(e.target.files)} />
            </div>);
    }
}

export default connect(
    (state: ApplicationState) => state.uploadReplay, // Selects which state properties are merged into the component's props
    UploadReplayState.actionCreators // Selects which action creators are merged into the component's props
)(UploadReplay) as typeof UploadReplay;