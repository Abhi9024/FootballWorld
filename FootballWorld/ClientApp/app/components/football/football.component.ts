import { Component,OnInit } from '@angular/core';
import { IClub } from '../../interface/IClub';
import { FootballService } from '../../service/football.service';
import {  FormGroup, FormBuilder, Validators } from '@angular/forms';
 
@Component({
    selector: 'football',
    templateUrl: './football.component.html',
    providers: [FootballService]
})
export class FootballComponent {

    clubs: IClub[];
    clubsForm: FormGroup;
    IsAddClubEnabled: boolean;

    club: IClub = {
        clubName: '',
        clubDescription: '',
        championsLeagueTitles: 0,
        leagueName: '',
        foundedDate: new Date(),
        leagueTitles: 0,
        clubNetWorth: 0,
        country: '',
        ranking: 0,
        state: '',
        defensive: 0,
        offensive: 0,
        europaLeagueTitles: 0
    };

    constructor(private footBallService: FootballService, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.getChampionsLeagueClubs();
        this.buildForm();
    };

    getChampionsLeagueClubs() {
        this.footBallService.getChampionsLeagueClubs()
            .subscribe(result => { this.clubs = result }, (err) => console.log(err));
    };

    buildForm() {
        this.clubsForm = this.formBuilder.group({
            clubName: [this.club.clubName, Validators.required],
            clubDescription: [this.club.clubDescription, Validators.required],
            championsLeagueTitles: [this.club.championsLeagueTitles, Validators.required],
            leagueName: [this.club.leagueName, Validators.required],
            foundedDate: [this.club.foundedDate, Validators.required],
            leagueTitles: [this.club.leagueTitles, Validators.required],
            clubNetWorth: [this.club.clubNetWorth, Validators.required],
            country: [this.club.country, Validators.required],
            ranking: [this.club.ranking, Validators.required],
            state: [this.club.state, Validators.required],
            defensive: [this.club.defensive, Validators.required],
            offensive: [this.club.offensive, Validators.required],
            europaLeagueTitles: [this.club.europaLeagueTitles, Validators.required]
        });
    };

    SubmitForm({ value, valid }: { value: IClub, valid: boolean }) {
        this.footBallService.addClub(value).subscribe(result => { this.getChampionsLeagueClubs() }, (err) => console.log(err));
    };

    toggleAddClub(): void {
        this.IsAddClubEnabled = (this.IsAddClubEnabled) ? false : true;
    };

    public doughnutChartLabels: string[] = ['Defensive', 'Offensive'];
    public doughnutChartType: string = 'pie';

    // events
    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }

}