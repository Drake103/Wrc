import * as React from "react";

import * as ReplaysAppState from "../../store/Replays";

type ReplayCardProps = ReplaysAppState.ReplayCardModel // ... state we've requested from the Redux store
    & typeof ReplaysAppState.actionCreators;

export class ReplayCard extends React.Component<ReplayCardProps, {}> {
    render() {
        const model = this.props;
        return (
            <div>{model.id}</div>
        );
    }
};