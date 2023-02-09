pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[url: 'https://dev.azure.com/<your_organization>/<your_project>/_git/<your_repository>']]])
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
                archiveArtifacts artifacts: '**/*.dll', fingerprint: true
            }
        }
        stage('Deploy') {
            steps {
                azureWebAppPublish azureCredentialsId: '<your_azure_credentials>', webAppName: '<your_web_app_name>', package: '**/*.zip'
                sh 'dotnet ef database update --context <your_database_context_name> --connection "<your_connection_string>"'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test <your_test_project>.csproj'
            }
        }
    }
}
pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[url: 'https://dev.azure.com/<your_organization>/<your_project>/_git/<your_repository>']]])
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
                archiveArtifacts artifacts: '**/*.dll', fingerprint: true
            }
        }
        stage('Deploy') {
            steps {
                azureWebAppPublish azureCredentialsId: '<your_azure_credentials>', webAppName: '<your_web_app_name>', package: '**/*.zip'
                sh 'dotnet ef database update --context <your_database_context_name> --connection "<your_connection_string>"'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test <your_test_project>.csproj'
            }
        }
    }
}
