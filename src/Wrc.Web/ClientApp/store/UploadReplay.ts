import { fetch, addTask } from "domain-task";
import { Action, Reducer } from "redux";
import { AppThunkAction } from "./";

import axios from "axios";

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface UploadReplayState {
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface BeginUploadAction {
    type: "BEGIN_UPLOAD";
}

interface UploadSuccessAction {
    type: "UPLOAD_SUCCESS"
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = BeginUploadAction | UploadSuccessAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    beginUpload: (fileList: FileList): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)

        const state = getState();

        const data = new FormData();
        data.append('formFile', fileList[0]);
        axios.post('/api/replays/upload', data).then((response) => {
            console.log(response);
        });
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: UploadReplayState = {};

export const reducer: Reducer<UploadReplayState> = (state: UploadReplayState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case "BEGIN_UPLOAD":
            return {
            };
        case "UPLOAD_SUCCESS":
            return {
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck = action;
    }

    return state || unloadedState;
};