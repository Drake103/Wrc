import { fetch, addTask } from "domain-task";
import { Action, Reducer } from "redux";
import { AppThunkAction } from "./";

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface ReplaysAppState {
    isLoading: boolean;
    start?: number;
    limit: number;
    replays: ReplayRowModel[];
}

export interface ReplayRowModel {
    id: number,
    uploadedAt: any,
    title: string,
    playersCount: number,
    mapName: string,
    victoryConditionName: string,
    gameVersion: number,
    downloadCount: number,
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestReplaysAction {
    type: "REQUEST_REPLAYS";
    start: number;
    limit: number;
}

interface ReceiveReplaysAction {
    type: "RECEIVE_REPLAYS";
    start: number;
    limit: number;
    replays: ReplayRowModel[];
}

interface ReplayListResponse {
    replays: ReplayRowModel[]
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestReplaysAction | ReceiveReplaysAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestReplays: (start: number, limit: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)

        const state = getState();

        if (start !== state.replays.start || limit !== state.replays.limit) {
            const fetchTask = fetch(`api/replays?start=${start}&limit=${limit}`)
                .then(response => response.json() as Promise<ReplayListResponse>)
                .then(
                    data => {
                        dispatch(
                            { type: "RECEIVE_REPLAYS", start: start, limit: limit, replays: data.replays });
                    });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: "REQUEST_REPLAYS", start: start, limit: limit });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: ReplaysAppState = { replays: [], limit: 50, isLoading: false };

export const reducer: Reducer<ReplaysAppState> = (state: ReplaysAppState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
    case "REQUEST_REPLAYS":
        return {
            start: action.start,
            limit: action.limit,
            isLoading: true,
            replays: new Array<ReplayRowModel>()
        };
    case "RECEIVE_REPLAYS":
        // Only accept the incoming data if it matches the most recent request. This ensures we correctly
        // handle out-of-order responses.
        if (action.start === state.start && action.limit === state.limit) {
            return {
                start: action.start,
                limit: action.limit,
                isLoading: false,
                replays: action.replays
            };
        }
        break;
    default:
        // The following line guarantees that every action in the KnownAction union has been covered by a case above
        const exhaustiveCheck = action;
    }

    return state || unloadedState;
};