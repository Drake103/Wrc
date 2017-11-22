import * as React from "react";
import { RouteComponentProps } from "react-router-dom";

export default class UploadReplay extends React.Component<RouteComponentProps<{}>, {}> {
    constructor(props: any) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(selectorFiles: FileList) {
        console.log(selectorFiles);
    }

    render() {
        return (
            <div>
                <input type="file" onChange={(e: any) => this.handleChange(e.target.files)}/>
            </div>);
    }
}