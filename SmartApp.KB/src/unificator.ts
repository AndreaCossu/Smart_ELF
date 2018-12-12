import { isAtom, isObject, isPlaceholder } from './matcher';

export function unify(query: any, data: any, ibinds: any): any {
    let res;
    const binds = JSON.parse(JSON.stringify(ibinds));
    for (const key of Object.keys(query)) {

        if (isAtom(key)) {
            if (data.hasOwnProperty(key)) { // key in data esiste ed è atom

                if ((isAtom(query[key]) && isAtom(data[key]))) {
                    if (query[key] === data[key]) {
                        res = true;
                    } else { return {s: false};  }
                } else {
                    if (isAtom(query[key]) && isPlaceholder(data[key])) {
                        if (!checkAndBind(data[key], query[key], binds)) {
                            return {s: false, binds};
                        }
                    } else {
                        if (isPlaceholder(query[key]) && isAtom(data[key])) {
                            if ( !checkAndBind(query[key], data[key], binds) ) {
                                return {s: false, binds };
                            }
                        } else {
                            if (isPlaceholder(query[key]) && isPlaceholder(data[key])) {
                                res = true;
                            } else {
                                if (isPlaceholder(query[key]) && isObject(data[key])) {
                                    if (!checkAndBind(query[key], data[key], binds)) {
                                        return {s: false, binds};
                                    }
                                } else {
                                    if (isObject(query[key]) && isPlaceholder(data[key])) {
                                        if (!checkAndBind(data[key], query[key], binds)) {
                                            return {s: false, binds};
                                        }
                                    } else {
                                        if (isObject(query[key]) && isObject(data[key])) {
                                           return unify(query[key], data[key], binds);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            } else {return {s: false, binds }; }
        } else {
            if (isPlaceholder(key)) {
                return false;
            }
        }
    }
    return {s: true, binds};
}

function checkAndBind(variable: any, value: any, binds: any) {

    if (binds.hasOwnProperty(variable) && binds.variable !== value) { return false; }
    binds[variable] = value;
    // fa le sostituzioni anche! tipo $x = {a:$y} + $y = $x = $x = {a:$x} --> occurcheck error
    return true;
}
