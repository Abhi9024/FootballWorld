import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { IClub } from '../interface/IClub';


@Injectable()
export class FootballService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    getChampionsLeagueClubs(): Observable<IClub[]>{
        return this.http.get(this.baseUrl +'/api/Football/GetClubs')
            .map(res => {
                let clubs = res.json();
                return clubs;
            }).catch(this.handleError);
    };

    addClub(club: IClub): Observable<IClub> {
       return this.http.post(this.baseUrl +'/api/Football/AddClub', club)
            .map(res => { return res.json() })
            .catch(this.handleError);
    };

    handleError(err: any) {
        console.log(err);
        return err;
    }

}