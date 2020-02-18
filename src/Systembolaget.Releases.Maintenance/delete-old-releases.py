import os
from datetime import datetime
import boto3
from botocore.exceptions import ClientError


def days_in_the_past(d):
    today = datetime.now()
    release_date = datetime.strptime(d, "%Y-%m-%d")
    return (release_date - today).days


def delete(event, context):
    aws_region = os.environ['AWS_REGION']
    dynamodb = boto3.resource('dynamodb', region_name=aws_region)
    table = dynamodb.Table('SystembolagetReleases')
    try:
        response = table.scan()
        for item in response['Items']:
            if days_in_the_past(item['ReleaseDate']) < -6:
                table.delete_item(
                    Key={
                        'ReleaseDate': item['ReleaseDate'],
                        'Group': item['Group']
                    }
                )
                print('Deleted ' + item['ReleaseDate'] + ' ' + item['Group'])
    except ClientError as e:
        print(e.response['Error']['Message'])
