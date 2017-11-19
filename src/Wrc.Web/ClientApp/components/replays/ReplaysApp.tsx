import * as React from "react";
import { RouteComponentProps } from "react-router-dom";
import { connect } from "react-redux";

import { ReplayList } from "./ReplayList";
import * as ReplaysAppState from "../../store/Replays";
import {ApplicationState} from "../../store/index";

// At runtime, Redux will merge together...
type ReplaysAppProps =
    ReplaysAppState.ReplaysAppState // ... state we've requested from the Redux store
    & typeof ReplaysAppState.actionCreators // ... plus action creators we've requested
    & RouteComponentProps<{ page: string }>; // ... plus incoming routing parameters

class ReplaysApp extends React.Component<ReplaysAppProps, {}> {

    componentWillMount() {
        // This method runs when the component is first added to the page

        const page = parseInt(this.props.match.params.page) || 1;

        const start = (page - 1) * this.props.limit;
        this.props.requestReplays(start, this.props.limit);
    }

    componentWillReceiveProps(nextProps: ReplaysAppProps) {
        // This method runs when incoming props (e.g., route params) change
        const page = parseInt(this.props.match.params.page) || 1;

        const start = (page - 1) * this.props.limit;
        this.props.requestReplays(start, this.props.limit);
    }

    render() {
        return (
            <div>
                <ReplayList {...this.props}/>
            </div>
        );
    }
}

export default connect(
    (state: ApplicationState) => state.replays, // Selects which state properties are merged into the component's props
    ReplaysAppState.actionCreators // Selects which action creators are merged into the component's props
)(ReplaysApp) as typeof ReplaysApp;