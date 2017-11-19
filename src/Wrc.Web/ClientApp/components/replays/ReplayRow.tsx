import * as React from "react";

import { ReplayRowModel } from "../../store/Replays";

export class ReplayRow extends React.Component<ReplayRowModel, {}> {
    render() {
        const model = this.props;
        return (
            <tr>
                <td>{model.uploadedAt}</td>
            </tr>
        );
    }
};